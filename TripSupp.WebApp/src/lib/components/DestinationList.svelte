<script lang="ts">
	import { onMount } from 'svelte'
	import { loadDestinations } from '../../stores/destinationsStore'
	import destinationsStore from '../../stores/destinationsStore'

	onMount(loadDestinations)
	$: destinations = $destinationsStore
</script>

{#if destinations.length > 0}
	<ul>
		{#each destinations as destination (destination.destinationId)}
			<li>
				<a href={`destination/${destination.destinationId}`}>{destination.title}</a>
			</li>
		{/each}
	</ul>
{:else}
	<p>Loading destinations...</p>
{/if}
