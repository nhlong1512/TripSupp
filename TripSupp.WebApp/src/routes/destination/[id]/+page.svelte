<script lang="ts">
	import type { IDestination } from '../../../interfaces/destination/destination.interface'
	import { onMount } from 'svelte'
	import { loadDestinationDetail } from '../../../stores/destinationDetailStore'
	import destinationDetailStore from '../../../stores/destinationDetailStore'

	export let data

	if (data) {
		console.log(data.id)
		onMount(async () => {
			await loadDestinationDetail(data.id)
		})
	}
	$: destinationDetail = $destinationDetailStore
</script>

<h1>Destination Detail</h1>
{#if destinationDetail}
	<h1>{destinationDetail.title}</h1>
{:else}
	<p>Loading destination Detail...</p>
{/if}
